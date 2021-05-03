import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/_model/member';
import { MembersService } from 'src/app/_service/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  // to store return value from service
  members: Member[];

  constructor(private membersService: MembersService) { }

  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers() {
    return this.membersService.getMembers().subscribe(members => {
      this.members = members;
    });
  }
}
