import { AuditedEntityDto, PagedAndSortedResultRequestDto } from "@abp/ng.core";

export interface TodoDto extends AuditedEntityDto<string> {
    title: string;
    description: string;
    status: number;
    priority: number;
    dueDate: string;
}

export interface CreateTodoDto {
    title: string;
    description: string;
    status: number;
    priority: number;
    dueDate: string;
}

export interface UpdateTodoDto extends AuditedEntityDto<string> {
    title: string;
    description: string;
    status: number;
    priority: number;
    dueDate: string;
}

export interface TodoPagedAndSortedListDto extends PagedAndSortedResultRequestDto {
    searchText: string;
    from: string;
    to: string;
    status: number;
    priority: number;
}