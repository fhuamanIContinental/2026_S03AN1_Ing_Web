import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstadoClienteComponentTs } from './estado-cliente.component.ts';

describe('EstadoClienteComponentTs', () => {
  let component: EstadoClienteComponentTs;
  let fixture: ComponentFixture<EstadoClienteComponentTs>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EstadoClienteComponentTs]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EstadoClienteComponentTs);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
