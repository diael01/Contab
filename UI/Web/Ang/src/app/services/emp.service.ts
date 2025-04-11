import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmpService {
  emps: any[] = [];
  constructor() { }

  add(emp: any)
  {
    this.emps.push(emp);
    console.log("new emp added to org");
  }
}
