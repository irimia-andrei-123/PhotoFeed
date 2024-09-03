
import {Component, OnInit} from '@angular/core';
import {MatChipInputEvent} from '@angular/material';
import { SearchService } from '../Services/SearchService/Search';
import { SearchImageModel } from '../Models/SearchImageModel';

@Component({
  selector: 'app-searchpage',
  templateUrl: './searchpage.component.html',
  styleUrls: ['./searchpage.component.css']
})
export class SearchpageComponent implements OnInit {

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes: number[] = [32, 13];
  tags: string[] = [];
  pictures: SearchImageModel[];

  constructor(private searchSvc: SearchService) {
  }

  ngOnInit() {
  }

  add(event: MatChipInputEvent) {
    const value = event.value;
    if ((value || '').trim()) {
      this.tags.push(value.trim());
    }

    const input = event.input;
    if (input) {
      input.value = '';
    }
  }

  remove(tag: string) {
    const index = this.tags.indexOf(tag);
    if (index >= 0) {
      this.tags.splice(index, 1);
    }
  }

  search() {
    if (this.tags.length) {
      const uniqueTags = this.tags.sort().filter(function(item, pos, ary) {return !pos || item !== ary[pos - 1]; });
      this.searchSvc.GetSearchResult(uniqueTags).subscribe(res => {
        this.pictures = res;
      },
      err => {
        alert('Failed to load images');
      });
    } else {
      alert('At least one tag requierd');
    }
  }

}
