export interface User {
  username: string;
  token: string;
}

// ts interface is different from regular interface since we are able to set the type

// TS Basics
// tslint:disable-next-line:no-inferrable-types
// const data: number = 42;

// const datas: string = '42';

// // can be a string or number
// let datans: number | string = 42;
// datans = '42';

// // infer class types
// interface Car {
//   color: string;
//   model: string;
//   topSpeed?: number;
// }
// // topSpeed optional;
// // const car1: Car =  {
// //   color: 2, //error object type safety
// //   model: 'BMW'
// // };

// const car2: Car = {
//   color: 'red',
//   model: 'Honda',
//   topSpeed: 100
// };

// // function type safety
// const multiply = (x: number, y: number): number => {
//   return x * y;
// };
