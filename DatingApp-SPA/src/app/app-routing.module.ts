import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { MemberListComponent } from './components/members/member-list/member-list.component';
import { MemberDetailComponent } from './components/members/member-detail/member-detail.component';
import { ListsComponent } from './components/lists/lists.component';
import { MessagesComponent } from './components/messages/messages.component';

import { AuthGuard } from './_guards/auth.guard';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

// add path & component to load
const routes: Routes = [
  { path: '', component: HomeComponent },
  // dummy route
  // group all the routes we want to have the canActivate guard
  { path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'members', component: MemberListComponent },
      { path: 'members/:username', component: MemberDetailComponent },
      { path: 'lists', component: ListsComponent },
      { path: 'messages', component: MessagesComponent },
    ]
  },
  { path: 'errors', component: TestErrorsComponent},
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent},
  // add route guard to path using canActiate passing the type of guard we would like to implement
  // { path: 'members', component: MemberListComponent, canActivate: [AuthGuard] },
  // { path: 'members/:id', component: MemberDetailComponent },
  // { path: 'lists', component: ListsComponent },
  // { path: 'messages', component: MessagesComponent },
  { path: '**', component: NotFoundComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
