export class Asset {
    tenantId: string;
    companyId: string;
    assetId: number;
    propType: string;
    description: string;
    location: string;
    department: string;

    constructor(attributes: {} = null) {
        this.attributes = attributes;
    }

    set attributes(attributes: {}) {
        for (var k in attributes) {
            this[k] = attributes[k];
        }
    }

    get attributes(): {} {
        return {
            tenantId: this.tenantId,
            companyId: this.companyId,
            assetId: this.assetId,
            propType: this.propType,
            description: this.description,
            location: this.location,
            department: this.department
        };
    }

}