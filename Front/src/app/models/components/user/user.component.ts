import {Component, TemplateRef} from '@angular/core';
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  modalRef?: BsModalRef;
  public users: any;
  public usersFiltrados: { id: string, name: string, code: string }[] = [];
  private filtroListado = '';

  constructor(private modalService: BsModalService) {
  }

  // Filtro
  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.usersFiltrados = this.filtroLista ? this.filtrarUsers(this.filtroLista) : this.users;
  }

  ngOnInit() {
    this.getUsers()
  }

  getUsers(): void {
    this.users = [{
      id: "1",
      name: "Carlos Vando"
    }, {
      id: "2",
      name: "Telma Vila "
    }]
    this.usersFiltrados = this.users
  }

  public filtrarUsers(filtrarPor: string): [] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.users.filter(
      (user: { name: string; }) => user.name.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }


  //Modal
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    // this.toastr.success('O Evento foi deletado com Sucesso.', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }


}
