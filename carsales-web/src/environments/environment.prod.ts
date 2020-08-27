export const environment = {
  production: false,
  environment: 'development',
  vehicle_service: {
    host: 'http://localhost:5000',
    path: {
      vehicle_list: '/vehicle/listings',
      vehicle_details: '/vehicle/:id/details',
    },
  },
};
