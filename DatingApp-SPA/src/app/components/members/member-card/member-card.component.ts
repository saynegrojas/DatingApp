import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/app/_model/member';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  // member from member-list prop
  @Input() member: Member;
  constructor() { }

  ngOnInit(): void {
  }

}
