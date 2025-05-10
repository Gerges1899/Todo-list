import { LocalizationService, isNullOrEmpty } from '@abp/ng.core';
import { ConfirmationService, ToasterService } from '@abp/ng.theme.shared';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TodoService } from '../TodoService';
import { SharedModule } from 'src/app/shared/shared.module';
import { CreateTodoDto, TodoDto, UpdateTodoDto } from '../Todo-Models';
import { DatePipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-todo',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './create-todo.component.html',
  styleUrl: './create-todo.component.scss'
})
export class CreateTodoComponent {
  todoForm: FormGroup;
  selectedTodoId: string = null;
  selectedTodo: TodoDto = {} as TodoDto || null;

  constructor(
    private fb: FormBuilder,
    private localization: LocalizationService,
    private confirmation: ConfirmationService,
    private toaster: ToasterService,
    private todoService: TodoService,
    private datePipe: DatePipe,
    private router: Router,
    private activatedRoute: ActivatedRoute,
  ) {}

  ngOnInit(): void {
    debugger
    this.buildTodoForm();
    this.activatedRoute.paramMap.subscribe(params => { 
      if (params.has('id')) {    
        debugger
        this.selectedTodoId = params.get("id");
        if (this.selectedTodoId) {
          this.todoService.GetById(this.selectedTodoId).subscribe({
            next: (res) => {
              if (res.succeed) {
                debugger
                this.selectedTodo = res.data;
                console.log('selectedTodo', this.selectedTodo);
                this.buildTodoForm();
              } else {
                this.toaster.error(res.message);
              }
            },
            error: (error) => {
              this.toaster.error(this.localization.instant(error.error?.error?.message));
            }
          });
        }
      }
    });    
  }

  buildTodoForm(): void {
    const dueDate = this.datePipe.transform(
      this.selectedTodo.dueDate || new Date(),
      'yyyy-MM-dd'
    );
  
    this.todoForm = this.fb.group({
      title: [this.selectedTodo.title || '', [Validators.required, Validators.maxLength(100)]],
      description: [this.selectedTodo.description || ''],
      status: [Number(this.selectedTodo.status)], // Ensure it's a number
      priority: [Number(this.selectedTodo.priority)], // Ensure it's a number
      dueDate: [dueDate],
    });
  }

  save(): void {
    if (this.todoForm.invalid) {
      this.toaster.error(this.localization.instant('Please fill in all required fields.'));
      return;
    }

    debugger
    const todoData = this.todoForm.value as CreateTodoDto;    
    let updateTodoData = {} as UpdateTodoDto;

    if(!isNullOrEmpty(this.selectedTodoId)){
      updateTodoData = this.todoForm.value as UpdateTodoDto;
      updateTodoData.id = this.selectedTodoId;
    }

    const request = this.selectedTodoId
    ? this.todoService.Update(updateTodoData, this.selectedTodoId)
    : this.todoService.Create(todoData);
    request.subscribe({
      next: (response) => {
        if (response.succeed) {          
          setTimeout(() => {
            this.toaster.success(this.localization.instant('saved successfully.'));
          }, 1000);
          this.router.navigate(['/todo-list']);
        } else {
          this.toaster.error(response.message);
        }
      },
      error: (error) => {
        this.toaster.error(this.localization.instant(error.error?.error?.message));
      }
    });
  }
}
