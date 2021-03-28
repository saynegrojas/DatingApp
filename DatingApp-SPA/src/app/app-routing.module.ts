import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { MemberListComponent } from './components/member-list/member-list.component';
import { MemberDetailComponent } from './components/member-detail/member-detail.component';
import { ListsComponent } from './components/lists/lists.component';
import { MessagesComponent } from './components/messages/messages.component';

import { AuthGuard } from './_guards/auth.guard';

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
      { path: 'members/:id', component: MemberDetailComponent },
      { path: 'lists', component: ListsComponent },
      { path: 'messages', component: MessagesComponent },
    ]
  },
  // add route guard to path using canActiate passing the type of guard we would like to implement
  // { path: 'members', component: MemberListComponent, canActivate: [AuthGuard] },
  // { path: 'members/:id', component: MemberDetailComponent },
  // { path: 'lists', component: ListsComponent },
  // { path: 'messages', component: MessagesComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
