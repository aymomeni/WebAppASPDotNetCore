class StoreCustomer {

    // private firstName:string >> automatically wires up a field for the class (only works in the constructor)
    constructor(private firstName:string, private lastName:string) {
        
    }

    public visits: number = 0; //fields
    private ourName: string;

    public showName() {
        alert(this.firstName + " " + this.lastName);
    }

    set name(val) {
        this.ourName = val;
    }

    get name() {
        return this.ourName;
    }
}
