import { Component, OnInit } from '@angular/core';
import { Category } from '../_models/Category';
import { MatFormField } from '@angular/material/form-field';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookService } from '../_services/book.service';
import { CategoryService } from '../_services/category.service';
import { BookCategoryService } from '../_services/bookCategory.service';

@Component({
  selector: 'app-add-category-to-book',
  templateUrl: './add-category-to-book.component.html',
  styleUrls: ['./add-category-to-book.component.css']
})
export class AddCategoryToBookComponent implements OnInit {
  categories: Category[] = [];

  constructor(private router: Router,
    private bookService: BookService,
    private categoryService: CategoryService,
    private bookCategoryService: BookCategoryService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(categories => {
      this.categories = categories;
    }, err => {
      this.toastr.error('An error occurred on get the records.');
    });
  }

  public onClick() {
    this.bookCategoryService.addBookCategory()
  }
}
