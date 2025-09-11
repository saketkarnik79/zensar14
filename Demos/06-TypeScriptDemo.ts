function getUserData(id: number):string {
  const user = {
    id,
    name: "Saket Karnik",
    role: "Partner - Delivery & Execution",
    active: true,
  };

  return `${user.name} (${user.role}) - ${user.active ? "Active" : "Inactive"}`;
}
let data:string = getUserData(1);
console.log(data);