import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioDeTareaComponent } from './formulario-de-tarea.component';

describe('FormularioDeTareaComponent', () => {
  let component: FormularioDeTareaComponent;
  let fixture: ComponentFixture<FormularioDeTareaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormularioDeTareaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioDeTareaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
