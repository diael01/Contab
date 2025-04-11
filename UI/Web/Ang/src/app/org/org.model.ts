interface IOrg {
     id: number;

     node: string;

     nodeName: string;

     parentNode: string;

     parentNodeName: string;

     nodeLevel: number;

     countyCode: string;

     location: string;

     codCor: number;

     codGrm: string;

     createdAt: Date;

     createdBy: string;

     updatedAt: Date;

     updatedBy: string;
}

export interface OrgDraft extends Partial<IOrg> {}