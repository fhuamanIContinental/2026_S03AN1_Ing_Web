import { ChangeDetectionStrategy, Component, effect, inject, input, output, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { EstadoClienteDto } from '../../../models/estado-cliente/estadoclienteDto';

export interface EstadoClientePayload {
  Codigo: string;
  Descripcion: string;
}

@Component({
  selector: 'app-estado-cliente-modal',
  imports: [ReactiveFormsModule],
  templateUrl: './estado-cliente-modal.component.html',
  styleUrl: './estado-cliente-modal.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EstadoClienteModalComponent {
  readonly visible = input(false);
  readonly estado = input<EstadoClienteDto | null>(null);

  readonly closed = output<void>();
  readonly saved = output<EstadoClientePayload>();

  readonly submitted = signal(false);

  private readonly formBuilder = inject(FormBuilder);

  readonly estadoClienteForm = this.formBuilder.nonNullable.group({
    Codigo: ['', [Validators.required, Validators.maxLength(20)]],
    Descripcion: ['', [Validators.required, Validators.maxLength(120)]],
  });

  constructor() {
    effect(() => {
      if (!this.visible()) {
        return;
      }

      const item = this.estado();
      this.submitted.set(false);

      if (item) {
        this.estadoClienteForm.setValue({
          Codigo: item.Codigo,
          Descripcion: item.Descripcion,
        });
        return;
      }

      this.estadoClienteForm.reset({ Codigo: '', Descripcion: '' });
    });
  }

  onClose(): void {
    this.closed.emit();
  }

  onSubmit(): void {
    this.submitted.set(true);
    if (this.estadoClienteForm.invalid) {
      this.estadoClienteForm.markAllAsTouched();
      return;
    }

    const formValue = this.estadoClienteForm.getRawValue();
    this.saved.emit({
      Codigo: formValue.Codigo.trim(),
      Descripcion: formValue.Descripcion.trim(),
    });
  }
}
