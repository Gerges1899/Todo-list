import { RestService } from "@abp/ng.core";
import { Injectable } from '@angular/core';
import { CreateTodoDto, TodoDto, TodoPagedAndSortedListDto } from "./Todo-Models";
import { ResponseAPI } from "../shared/shared.models";

@Injectable({
    providedIn: 'root'
})
export class TodoService {

   apiName = 'Default';
   constructor(private restService: RestService) {}

   GetListFiltered = (filters: TodoPagedAndSortedListDto) => 
   this.restService.request<any, ResponseAPI>({
    method: 'GET',
    url: `/api/app/todo/todo-filtered-list`,
    params: {
        searchText: filters.searchText,
        from: filters.from,
        to: filters.to,
        status: filters.status,
        priority: filters.priority,
        sorting: filters.sorting,
        skipCount: filters.skipCount,
        maxResultCount: filters.maxResultCount,
    },
   },
   { apiName: this.apiName });

   Delete = (id: string) =>
   this.restService.request<any, ResponseAPI>({
    method: 'DELETE',
    url: `/api/app/todo/${id}/todo`,
   },
   { apiName: this.apiName });

   GetById = (id: string) =>
   this.restService.request<any, ResponseAPI>({
    method: 'GET',
    url: `/api/app/todo/${id}/by-id`,
   },
   { apiName: this.apiName });

    Create = (input: CreateTodoDto) =>
    this.restService.request<any, ResponseAPI>({
        method: 'POST',
        url: `/api/app/todo/todo`,
        body: input,
    },
    { apiName: this.apiName });

    Update = (input: CreateTodoDto, id: string) =>
    this.restService.request<any, ResponseAPI>({
        method: 'PUT',
        url: `/api/app/todo/${id}/todo`,
        body: input,
    },
    { apiName: this.apiName });
}