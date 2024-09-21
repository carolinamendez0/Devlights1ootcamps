import { Component, Input , Output, EventEmitter } from '@angular/core';
import { TareaModel } from '../model/TareaModel';

@Component({
  selector: 'app-tarea',
  standalone: true,
  imports: [],
  // templateUrl: './tarea.component.html',
  styleUrl: './tarea.component.css',
  template: `
    <div>
      <input type="checkbox" [checked]="tarea?.completada" (change)="marcarCompleta()"/>
      <span>{{ tarea?.titulo }}</span>
      <button (click)="eliminarTarea()">Eliminar</button>
    </div>
  `
})


export class TareaComponent {
 // Un componente que recibe una tarea como @Input()
 @Input() tarea: TareaModel | undefined;
 //  @Output() cuando se marca como completada o se elimina.
@Output() tareaCompleta: EventEmitter<boolean> = new EventEmitter<boolean>();
@Output() tareaEliminada: EventEmitter<void> = new EventEmitter();

marcarCompleta () {
  this.tareaCompleta.emit(true);
}
eliminarTarea() {
  this.tareaEliminada.emit();
}
}
