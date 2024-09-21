export interface Tarea {
  id: number;
  titulo: string;
  completada: boolean;
}

export class TareaModel implements Tarea {
  constructor(public id: number, public titulo: string, public completada: boolean = false) {}
}
