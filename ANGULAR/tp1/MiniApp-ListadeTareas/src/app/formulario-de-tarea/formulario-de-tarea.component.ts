import { Component, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms'; // Importamos FormsModule
import { TareaModel } from '../model/TareaModel';

@Component({
  selector: 'app-formulario-de-tarea',
  standalone: true,
  imports: [FormsModule], // Importamos FormsModule aquí
  template: `
    <input [(ngModel)]="titulo" placeholder="Nueva tarea" />
    <button (click)="agregarTarea()">Agregar</button>
  `,
  styleUrls: ['./formulario-de-tarea.component.css']
})
export class FormularioDeTareaComponent {
  titulo: string = '';
  @Output() nuevaTarea: EventEmitter<TareaModel> = new EventEmitter();

  agregarTarea() {
    if (this.titulo.trim()) {
      const tarea = new TareaModel(Date.now(), this.titulo);
      this.nuevaTarea.emit(tarea);
      this.titulo = '';
    }
  }
}
