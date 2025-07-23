import { Pipe, PipeTransform } from '@angular/core';
import { DropDownDataService } from '../data/dropdown-data-service';
import { StringHelper } from '../utils/string-helper';

@Pipe({
  name: 'question',
  standalone: true
})
export class QuestionPipe implements PipeTransform {
  stringHelper: StringHelper;
  constructor(private sharedDataService: DropDownDataService) {
    this.stringHelper = new StringHelper(sharedDataService);
  }

  transform(value: any, topic: any, problem : any, diffTopic : any): any {
    var result = this.stringHelper.ReplaceQuestionFormatsWithoutDropDownValue(value, topic,problem,diffTopic,);
    return result;
  }
}
