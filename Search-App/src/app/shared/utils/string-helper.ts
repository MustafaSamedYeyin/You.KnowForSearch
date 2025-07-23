import { DropDownDataService } from '../data/dropdown-data-service';

export class StringHelper {

  constructor(private sharedDataService: DropDownDataService) {

  }
  public ReplaceQuestionFormats(value: any, topic: any, problem: any,diffTopic : any, deckText: string): any {
    var result = this.ReplaceQuestionFormatsWithoutDropDownValue(value,topic,problem,diffTopic);
    result = result.replace("{1}", this.sharedDataService.getDropDownName());
    
    return result;
  }
  public ReplaceQuestionFormatsWithoutDropDownValue(value: any, topic: any, problem: any,diffTopic : any): any {
    var result = value.replace("{0}", topic);
    result = result.replace("{2}", problem);
    result = result.replace("{3}", diffTopic);
    result = result.replace(", {1}", "");

    return result;
  }
}
