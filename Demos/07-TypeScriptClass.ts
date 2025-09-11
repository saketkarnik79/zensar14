class UserProfile {
  constructor(private id: number, private name: string, private role: string) {}

  getSummary() {
    return `${this.name} (${this.role})`;
  }

  isExecutive() {
    //return this.role.includes("Partner");
  }
}

const saket = new UserProfile(1, "Saket Karnik", "Partner - Delivery & Execution");
console.log(saket.getSummary()); // Saket Karnik (Partner - Delivery & Execution)
//console.log(saket.isExecutive()); // true
