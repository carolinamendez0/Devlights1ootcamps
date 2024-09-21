import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadeTareasComponent } from './listade-tareas.component';

describe('ListadeTareasComponent', () => {
  let component: ListadeTareasComponent;
  let fixture: ComponentFixture<ListadeTareasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListadeTareasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListadeTareasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
