import { OAuthService } from 'angular-oauth2-oidc';
import { environment } from './../../../environment';
import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { DropdownService } from '../shared/proxy/services/drop-down/dropdown.service';
import { DropDownDataService } from '../shared/data/dropdown-data-service';
import { DropDown } from '../shared/proxy/services/drop-down/dtos/dropdown';
import { RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css',
  imports: [FormsModule, RouterLink, RouterOutlet, CommonModule]
})
export class NavBarComponent implements OnInit {

  public isMobile: boolean = false;
  environment = environment;
  focus: DropDown[] = [];
  focusSelected: DropDown = { } as DropDown;

  constructor(private oauthService: OAuthService, private service: DropdownService, private sharedDataService: DropDownDataService) { }
  ngOnInit(): void {
    this.SetDropDownData();
    this.IsMobile();
  }
 
  private SetDropDownData() {
    this.service.getDropdownData().subscribe(
      (dropdownItems: DropDown[]) => {
        dropdownItems.forEach((item: DropDown) => {
          this.focus.push(
            {
              id: item.id,
              name: item.name,
              isFocus: item.isFocus,
              sort: item.sort,
              createTime: item.createTime,
              updateTime: item.updateTime,
              isActive: item.isActive
            });
        });
      }
    );
  }

  private IsMobile() {
    if (window.innerWidth < 768) {
      this.isMobile = true;
    } else {
      this.isMobile = false;
    }
  }

  dropDownChange(dropDown: DropDown) {
    this.focusSelected = dropDown;
    this.sharedDataService.updateDropDownValue(dropDown);
  }
}