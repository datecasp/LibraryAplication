import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookCategory } from '../_models/BookCategory';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class BookCategoryService {
  private baseUrl: string = environment.baseUrl + 'api/';

  constructor(private http: HttpClient) { }
  //IMPLEMENTAR LOGICA AddCategoryToBook(bookId, categoryID)
  public async addBookCategory(bookCategory: BookCategory) {
    return await this.http.post(this.baseUrl + 'bookCategory/AddCategory/Book/' + bookCategory.bookId + '/categoryId/' + bookCategory.categoryId, bookCategory);
  }

    //IMPLEMENTAR LOGICA RemoveCategoryFromBook(bookId, categoryID)
  public deleteBookCategory(id: number) {
    return this.http.delete(this.baseUrl + 'books/' + id);
  }

  public searchBooksWithCategory(categoryId: number): Observable<BookCategory[]> {
    return this.http.get<BookCategory[]>(`${this.baseUrl} + books/booksWithCategory/categoryId//${categoryId}`);
  }

  public searchCategoriesOfBook(bookId: number): Observable<BookCategory[]> {
    return this.http.get<BookCategory[]>(`${this.baseUrl} + categpries/categoriesOfBook/bookId//${bookId}`);
  }
}
