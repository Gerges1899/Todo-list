import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'statusLabel',
  standalone: true
})
export class StatusLabelPipe implements PipeTransform {
  transform(value: number): string {
    switch (value) {
        case 0:
          return '<i class="fas fa-hourglass-half text-warning me-1"></i> Pending';
        case 1:
          return '<i class="fas fa-spinner text-primary me-1"></i> In Progress';
        case 2:
          return '<i class="fas fa-check-circle text-success me-1"></i> Completed';
        default:
          return '<i class="fas fa-question-circle text-muted me-1"></i> Unknown';
      }
  }
}
