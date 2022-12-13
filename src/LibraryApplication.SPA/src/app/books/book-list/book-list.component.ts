import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from 'src/app/_services/book.service';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationDialogService } from 'src/app/_services/confirmation-dialog.service';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { BookCategoryService } from '../../_services/bookCategory.service';
import { BookCategory } from '../../_models/BookCategory';


@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  public books: any;
  public listComplet: any;
  public bookId: number = -11;
  public categoryId: number = -11;
  public bookCategory: BookCategory = new BookCategory();
  public searchTerm: string ="";
  public searchValueChanged: Subject<string> = new Subject<string>();

  constructor(private router: Router,
    private boookService: BookService,
    private bookCategoryService: BookCategoryService,
    private toastr: ToastrService,
    private confirmationDialogService: ConfirmationDialogService) { }

  ngOnInit() {
    this.getValues();

    this.searchValueChanged.pipe(debounceTime(1000))
      .subscribe(() => {
        this.search();
      });
  }

  private getValues() {

    this.boookService.getBooks().subscribe(books => {
      this.books = books;
      this.listComplet = books;
    });
  }

  public GetCategoryId(categoryId: number) {
    this.bookCategory.bookId = this.bookId;
    this.bookCategory.categoryId = categoryId;
    this.bookCategoryService.addBookCategory(this.bookCategory);
  }


  public addBook() {
    this.router.navigate(['/book']);
  }

  public editBook(bookId: number) {
    this.router.navigate(['/book/' + bookId]);
  }

  public deleteBook(bookId: number) {
    this.confirmationDialogService.confirm('Atention', 'Do you really want to delete this book?')
      .then(() =>
        this.boookService.deleteBook(bookId).subscribe(() => {
          this.toastr.success('The book has been deleted');
          this.getValues();
        },
          err => {
            this.toastr.error('Failed to delete the book.');
          }))
      .catch(() => '');
  }

  private search() {
    if (this.searchTerm !== '') {
      this.boookService.searchBooksWithCategory(this.searchTerm).subscribe(book => {
        this.books = book;
      }, error => {
        this.books = [];
      });
    } else {
      this.boookService.getBooks().subscribe(books => this.books = books);
    }
  }
}
