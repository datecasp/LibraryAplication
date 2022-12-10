import { Component, OnInit } from '@angular/core';
import { Category } from '../_models/Category';
import { MatFormField } from '@angular/material/form-field';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookService } from '../_services/book.service';
import { CategoryService } from '../_services/category.service';

@Component({
  selector: 'app-add-category-to-book',
  templateUrl: './add-category-to-book.component.html',
  styleUrls: ['./add-category-to-book.component.css']
})
export class AddCategoryToBookComponent implements OnInit {

  constructor(private router: Router,
    private bookService: BookService,
    private catService: CategoryService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  categories: Category[] = [
    { id: 0, categoryName: 'hpal' },
    { id: 1, categoryName: 'eryht' },
    { id: 2, categoryName: 'dfvfv' }
  ];
}
