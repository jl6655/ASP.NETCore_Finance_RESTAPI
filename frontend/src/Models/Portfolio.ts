export type PortfolioGet = {
    id: number;
    symbol: string;
    companyName: string;
    purchaseL: number;
    lastDiv: number;
    industry: string;
    marketCap: number;
    comments: any;
};

export type PortfolioPost = {
    symbol: string;
    
};