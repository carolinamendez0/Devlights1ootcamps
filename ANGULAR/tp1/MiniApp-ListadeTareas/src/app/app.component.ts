import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Tarea, TareaModel } from './model/TareaModel';
import { ListadeTareasComponent } from "./listade-tareas/listade-tareas.component";
import { FormularioDeTareaComponent } from "./formulario-de-tarea/formulario-de-tarea.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ListadeTareasComponent, FormularioDeTareaComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
marcarComoCompletada(_t6: any) {
throw new Error('Method not implemented.');
}
  title = 'MiniApp-ListadeTareas';
    tareas: TareaModel[] = [];

    agregarTarea(nuevaTarea: TareaModel) {
      this.tareas.push(nuevaTarea);
    }
}
