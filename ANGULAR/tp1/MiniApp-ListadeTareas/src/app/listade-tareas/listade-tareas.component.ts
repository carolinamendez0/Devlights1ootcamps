import { Component } from '@angular/core';
import { TareaModel } from '../model/TareaModel';
import { TareaComponent } from "../tarea/tarea.component";


@Component({
  selector: 'app-listade-tareas',
  standalone: true,
  imports: [TareaComponent],
  // templateUrl: './listade-tareas.component.html',
  template: `
    <div *ngIf="tareas.length === 0">No hay tareas</div>
    <div *ngFor="let tarea of tareas">
      <app-tarea [tarea]="tarea" (tareaCompleta)="marcarTareaCompleta(tarea)" (tareaEliminada)="eliminarTarea(tarea)"></app-tarea>
    </div>
  `,
  styleUrl: './listade-tareas.component.css'
})
export class ListadeTareasComponent {
  // Muestra todas las tareas usando *ngFor, y muestra un mensaje con *ngIf si no hay tareas.

  tareas: TareaModel[] = [];

  marcarTareaCompleta(tarea: TareaModel) {
    tarea.completada = true;
  }

  eliminarTarea(tarea: TareaModel) {
    this.tareas = this.tareas.filter(t => t !== tarea);
  }
}
