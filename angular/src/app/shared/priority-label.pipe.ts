import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'priorityLabel',
  standalone: true
})
export class PriorityLabelPipe implements PipeTransform {
  transform(value: number): string {
    switch (value) {
        case 0:
          return '<i class="fas fa-arrow-down text-secondary me-1"></i> Low';
        case 1:
          return '<i class="fas fa-arrow-right text-info me-1"></i> Medium';
        case 2:
          return '<i class="fas fa-arrow-up text-danger me-1"></i> High';
        default:
          return '<i class="fas fa-question text-muted me-1"></i> Unknown';
      }
  }
}
