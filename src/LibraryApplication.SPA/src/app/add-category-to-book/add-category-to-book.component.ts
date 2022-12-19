import { Component, OnInit, Input } from '@angular/core';
import { Category } from '../_models/Category';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookService } from '../_services/book.service';
import { CategoryService } from '../_services/category.service';
import { BookCategoryService } from '../_services/bookCategory.service';
import { Book } from '../_models/Book';
import { BookCategoryDto } from '../_models/BookCategoryDto';

@Component({
  selector: 'app-add-category-to-book',
  templateUrl: './add-category-to-book.component.html',
  styleUrls: ['./add-category-to-book.component.css']
})
export class AddCategoryToBookComponent implements OnInit {
  categories: Category[] = [{ id: 1, categoryName: "una" }, { id: 2, categoryName: "dos" }];
  bookIdList: number[] = [];
  public categoryId: number = -11;
  public categoriesString: string = "";
  bookCategoryDto: BookCategoryDto = { bookId: 0, categoryId: 0 }

  @Input() book: Book = {id: -99, title: "qqqqqqqqq", author: "hijo"};
    value: number = -33;



constructor(private router: Router,
  private categoryService: CategoryService,
  private bookCategoryService: BookCategoryService,
  private toastr: ToastrService) { }

  ngOnInit(): void {

    this.categoryService.getCategories().subscribe(categories => {
      this.categories = categories;
      this.UpdateCategoriesList();
    }, err => {
      this.toastr.error('An error occurred on get the records.');
    });

  }

  private async UpdateCategoriesList() {
    (await this.bookCategoryService.searchCategoriesOfBook(this.book.id)).subscribe(category => {
      for (let i = 0; i < category.length; i++) {
        category.forEach(cat => this.categoriesString.concat(cat.categoryName)) ;
      }
    });
    this.toastr.error(this.categoriesString);
  }

  public async SendBookCategoryToInsert(category: Category) {
    this.bookCategoryDto.bookId = this.book.id,
    this.bookCategoryDto.categoryId = category.id;

    (await this.bookCategoryService.addBookCategory(this.bookCategoryDto)).subscribe(() => {
      this.toastr.success('Registration successful');
    }, () => {
      this.toastr.error('An error occurred on insert the record.');
    });
    this.UpdateCategoriesList();
  }
}
