import { Component, OnInit } from '@angular/core';
import { TrCurrencyPipe } from 'tr-currency';
import { ShoppingCartModel } from '../../models/shopping-cart.model';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ShoppingCartService } from '../../service/shopping-cart.service';
import { AuthService } from '../../service/auth.service';
import { api } from '../../constants/api';
import { SwalService } from '../../service/swal.service';
import { MessageService } from 'primeng/api';
import { ErrorService } from '../../service/error.service';

@Component({
  selector: 'app-shopping-cart',
  standalone: true,
  imports: [TrCurrencyPipe],
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.css'
})
export class ShoppingCartComponent implements OnInit {
  carts: ShoppingCartModel[] = []

  constructor(
    private http: HttpClient,
    public _cart: ShoppingCartService,
    private auth: AuthService,
    private swal: SwalService,
    private primeng: MessageService,
    private error: ErrorService) { } //yapıcı metod=> class çağrıldığı esnada ilk çalışan metot

  ngOnInit(): void { } //implement ile constructor 'da kullanılan metotlar bestp te buraya yazılır.


  decrement(cart: ShoppingCartModel) {
    if (cart.quantity === 1) {
      const response = confirm("Ürünü sepetten kaldırmak istiyor musunuz?")

      if (response) {
        this._cart.decrement(cart.productId);
      }
    } else {
      this._cart.decrement(cart.productId);
    }
  }

  remove(id: number) {
    this.swal.fire("Sil", "Ürünü sepetten kaldırmak istiyor musunuz?", "Sil", "question", ()=> {
      this.http.get(`${api}/ShoppingCarts/RemoveById?id=${id}`, {
        headers: {
          "Authorization": "Bearer " + this.auth.token
        }
      })
        .subscribe({
          next: () => {
            this._cart.getAll();
          },
          error: (err: HttpErrorResponse)=> this.error.errorHandler(err)
        })
    })
  }

  pay() {
    this.swal.fire("Ödeme Yap", "Ödeme işlemini onaylıyor musunuz?", "Öde", "question", () => {
      this.http.get(`${api}/ShoppingCarts/Pay`, {
        headers: {
          "Authorization": "Bearer " + this.auth.token
        }
      })
        .subscribe({
          next: () => {
            this._cart.getAll();
          },
          error: (err: HttpErrorResponse)=> this.error.errorHandler(err)
        })
    })

  }
}
