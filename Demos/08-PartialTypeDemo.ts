type User = {
  id: number;
  name: string;
  role: string;
};
//const updateUser = (user:User)=>{
const updateUser = (user:Partial<User>)=>{
	return {...user}
}
let u=updateUser({name: "Saket"});
console.log(u);