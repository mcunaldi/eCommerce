import { Component } from '@angular/core';
import { TrCurrencyPipe } from 'tr-currency';
import { AuthService } from '../../service/auth.service';
import { ProductModel } from '../../models/product.model';
import { HttpClient, HttpErrorResponse, } from '@angular/common/http';
import { ShoppingCartService } from '../../service/shopping-cart.service';
import { CommonModule } from '@angular/common';
import { api } from '../../constants/api';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { ErrorService } from '../../service/error.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, TrCurrencyPipe],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  products: ProductModel[] = [];
  isAuthenticated: boolean = false;

  constructor(
    private auth: AuthService,
    private http: HttpClient,
    public cart: ShoppingCartService,
    private message: MessageService,
    private error: ErrorService) {
    this.isAuthenticated = this.auth.isAuthenticated();

    this.getAllProduct();
  }

  show() {
    this.message.add({ severity: 'success', summary: 'Success', detail: 'Message Content' });
  }

  getAllProduct() {
    this.http.get(`${api}/Home/GetProducts`, {
      headers: {
        "Authorization": "Bearer " + this.auth.token
      }
    })
      .subscribe({
        next: (res: any) => {
          this.products = res;
        },
        error: (err: HttpErrorResponse)=> this.error.errorHandler(err)
      })
  }

  getCartsCountByProductId(productId: number) {
    const cart = this.cart.carts.find(p => p.productId == productId)
    return cart == undefined ? 0 : cart?.quantity;
  }



  showDownButton(event: any, productId: number) {
    const id = event.target.id;
    const count = this.getCartsCountByProductId(productId);
    if (count === 0) {
      event.target.classList.add("d-none");
      const el: any = document.querySelector("#" + id + "+ div");
      el.className = "d-flex mt-2"
    }

  }

  showOriginalButton(event: any, productId: number) {
    const count = this.getCartsCountByProductId(productId);
    if (count === 0) {
      const divId: string = event.target.id;
      const buttonId = divId.replace("div-", "btn-")

      const buttonEl = document.getElementById(buttonId);
      buttonEl?.classList.remove("d-none");

      const el: any = document.querySelector("#" + buttonId + "+ div");
      el.className = "d-none me-2"
    }
  }


}


// getAll(){
//   fetch("/assets/db.json")
//   .then(res=> res.json())
//   .then((data:any)=> this.products = data.products)
// }