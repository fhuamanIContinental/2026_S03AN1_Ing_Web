import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import { EstadoClienteDto } from '../../../models/estado-cliente/estadoclienteDto';
import { EstadoClienteModalComponent, EstadoClientePayload } from './estado-cliente-modal.component';

@Component({
  selector: 'app-estado-cliente.component.ts',
  imports: [EstadoClienteModalComponent],
  templateUrl: './estado-cliente.component.ts.html',
  styleUrl: './estado-cliente.component.ts.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EstadoClienteComponentTs {
  readonly showModal = signal(false);
  readonly selectedEstado = signal<EstadoClienteDto | null>(null);
  readonly estadosCliente = signal<EstadoClienteDto[]>([
    { Id: 1, Codigo: 'ACT', Descripcion: 'Cliente activo' },
    { Id: 2, Codigo: 'INA', Descripcion: 'Cliente inactivo' },
    { Id: 3, Codigo: 'SUS', Descripcion: 'Cliente suspendido' },
  ]);

  openCreateModal(): void {
    this.selectedEstado.set(null);
    this.showModal.set(true);
  }

  openEditModal(item: EstadoClienteDto): void {
    this.selectedEstado.set(item);
    this.showModal.set(true);
  }

  closeModal(): void {
    this.showModal.set(false);
    this.selectedEstado.set(null);
  }

  saveEstado(payload: EstadoClientePayload): void {
    const selected = this.selectedEstado();

    if (selected) {
      this.estadosCliente.update((items) =>
        items.map((item) =>
          item.Id === selected.Id
            ? { ...item, Codigo: payload.Codigo.trim(), Descripcion: payload.Descripcion.trim() }
            : item,
        ),
      );
      this.closeModal();
      return;
    }

    const newItem: EstadoClienteDto = {
      Id: this.getNextId(),
      Codigo: payload.Codigo.trim(),
      Descripcion: payload.Descripcion.trim(),
    };

    this.estadosCliente.update((items) => [...items, newItem]);
    this.closeModal();
  }

  onDelete(id: number): void {
    this.estadosCliente.update((items) => items.filter((item) => item.Id !== id));
  }

  private getNextId(): number {
    const ids = this.estadosCliente().map((item) => item.Id);
    return ids.length > 0 ? Math.max(...ids) + 1 : 1;
  }

}
