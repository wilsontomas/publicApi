import { Injectable } from '@angular/core';
import { IMenuItem } from '../Model/interfaces/ImenuItem';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  constructor() { }

  getAllLinks():IMenuItem[]{
    let menuItems:IMenuItem[] =[
      {
        name:'Inicio',
        icon:'home',
        url:'/account/account-service/home',
        rol:3
      },
      {
        name:'Perfil',
        icon:'account_circle',
        url:'/account/account-service/profile',
        rol:3
      },
      {
        name:'Lista de Usuarios',
        icon:'list',
        url:'/admin/admin-management/user-list',
        rol:2
      },
      {
        name:'Crear Usuarios',
        icon:'add_box',
        url:'/admin/admin-management/create-user',
        rol:2
      },
      {
        name:'Lista de Tareas',
        icon:'sort',
        url:'/task/task-service/task-list',
        rol:1
      },
      {
        name:'Crear Tarea',
        icon:'add_comment',
        url:'/task/task-service/add-task',
        rol:1
      }
    ];
    return menuItems;
  }

  
}
