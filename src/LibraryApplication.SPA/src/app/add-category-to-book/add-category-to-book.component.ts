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
    }, err => {
      this.toastr.error('An error occurred on get the records.');
    });
  }

  public async SendBookCategoryToInsert(category: Category) {
    this.bookCategoryDto.bookId = this.book.id,
    this.bookCategoryDto.categoryId = category.id;

    (await this.bookCategoryService.addBookCategory(this.bookCategoryDto)).subscribe(() => {
      this.toastr.success('Registration successful');
      this.router.navigate(['/books']);
    }, () => {
      this.toastr.error('An error occurred on insert the record.');
    });
    //this.bookCategoryService.addBookCategory(this.bookCategory);
    alert("book: " + this.book.id + "    cat: " + category.id);
    //alert(this.bookCategoryService.addBookCategory(this.bookCategoryDto));

  }
}
