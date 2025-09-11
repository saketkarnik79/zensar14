type User = {
  id: number;
  name: string;
  role: string;
};
//const updateUser = (user:User)=>{
const updateUser = (user:Partial<User>)=>{
	return {...user}
}
function greet(name:string){ 
  console.log("Hello " + name);
}
//greet(10);
let u=updateUser({name: "Saket"});
console.log(u);