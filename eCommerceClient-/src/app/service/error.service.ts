import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(private primeng: MessageService) { }

  errorHandler(err: HttpErrorResponse) {
    console.log(err);

    switch (err.status) {
      case 0:
        this.primeng.add({ severity: "info", detail: "API çalışmıyor.", summary: "API DEACTIVE" });
        break;

      case 400:
        this.primeng.add({ severity: "error", detail: err.error.message, summary: "Hatalı Giriş!" });
        break;

      case 404:
        this.primeng.add({ severity: "info", detail: "API adresi bulunamadı.", summary: "API CONTROL" });
        break;

      case 422:
        for (const e of err.error) {
          this.primeng.add({ severity: "info", detail: e, summary: "VALIDATION ERROR" });
        }
        break;
    }
  }
}
