export interface AppConfig {
  environment: string;
  vehicle_service: EndpointDetails;
}

export interface EndpointDetails {
  host: string;
  path: Object;
}

export type ListingType = 'Used' | 'New';

export interface Vehicle {
  id: string;
  listingType: ListingType;
  odometer: number;
  photo: string;
  price: number;
  sellerType: string;
  state: string;
  title: string;
}

export interface VehicleDetail extends Vehicle {
  photos: string[];
  features: Feature[];
}

export interface Feature {
  name: string;
  group: string;
}
