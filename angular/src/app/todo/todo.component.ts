import { AbpApplicationLocalizationService, ListService, LocalizationService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit , AfterViewInit, ViewChild, ElementRef} from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Confirmation, ConfirmationService, ToasterService } from '@abp/ng.theme.shared';
import { TodoDto, TodoPagedAndSortedListDto } from './Todo-Models';
import { TodoService } from './TodoService';
import { StatusLabelPipe } from '../shared/status-label.pipe';
import { PriorityLabelPipe } from '../shared/priority-label.pipe';

@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [SharedModule, StatusLabelPipe, PriorityLabelPipe],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.scss'
})
export class TodoComponent {
  todoFilterForm: FormGroup;
  todoList: TodoDto[] = [];
  ListTodo = { items: [], totalCount: 0 } as PagedResultDto<TodoDto>;
  perPage: number = 10; 
  currentPage: number = 1;
  sorting: string = "";

  constructor(
    private fb: FormBuilder,
    private localization: LocalizationService,
    private confirmation: ConfirmationService,
    private toaster: ToasterService,
    private todoService: TodoService,
  ) {}

  ngOnInit(): void {
    this.buildTodoFilterForm();
    this.getTodoList();
  }

  buildTodoFilterForm(): void {
    this.todoFilterForm = this.fb.group({
      searchText: [''],
      from: [''],
      to: [''],
      status: [null],
      priority: [null],
      maxResultCount: [this.perPage],
      skipCount: [this.perPage * (this.currentPage - 1)],
      sorting: [this.sorting]
    });
  }

  getTodoList(): void {
    const filter = this.todoFilterForm.value as TodoPagedAndSortedListDto;
    this.todoService.GetListFiltered(filter).subscribe({
      next: (response) => {
        if (response.succeed) {
          this.ListTodo = response.data;
          this.todoList = this.ListTodo.items;
          console.log('todo List', this.todoList);
        } else {
          this.toaster.error(response.message);
        }
      },
      error: (error) => {
        this.toaster.error(error.error?.error?.message);
      }
    });
  }

  resetFilter(): void {
    this.todoFilterForm.reset();
    this.todoFilterForm.patchValue({
      maxResultCount: this.perPage,
      skipCount: this.perPage * (this.currentPage - 1),
      sorting: this.sorting
    });
    this.getTodoList();
  }

  onDelete(todo: TodoDto): void {
    this.confirmation.warn('::AreYouSureToDelete', 'AbpAccount::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.todoService.Delete(todo.id).subscribe({
          next: () => {
            this.toaster.success(this.localization.instant('::DeletedSuccessfully'));
            this.getTodoList();
          },
          error: (err) => {
            this.toaster.error(err.error?.error?.message);
          }
        });
      }
    });
  }

  onMarkComplete(todo: TodoDto): void {
    this.confirmation.warn('::AreYouSureToMarkComplete', 'AbpAccount::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        todo.status = 2;
        this.todoService.Update(todo, todo.id).subscribe({
          next: () => {
            this.toaster.success(this.localization.instant('::MarkedAsComplete'));
            window.location.reload();
          },
          error: (err) => {
            this.toaster.error(err.error?.error?.message);
          }
        });
      }
    });
  }

}
