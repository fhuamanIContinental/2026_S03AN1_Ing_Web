import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { Dashboard } from './pages/dashboard/dashboard';


export const routes: Routes = [


    {path: '', component: Login},
    {path: 'Dashboard', component: Dashboard,
        children: [
            {
                path: 'estado-cliente', loadComponent: () => import('./pages/mantenimiento/estado-cliente.component.ts/estado-cliente.component.ts').then(m => m.EstadoClienteComponentTs)
            }
        ]
    },

];
