import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: "orderBy",
  pure: false
})
export class OrderByPipe implements PipeTransform {
  transform(value: object[], sortFunction?: any): any[] {
    console.log("OrderByPipe")
    return value.sort(sortFunction);
  }
}
