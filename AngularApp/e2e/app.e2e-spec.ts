import { CustomersAppPage } from './app.po';

describe('customers-app App', () => {
  let page: CustomersAppPage;

  beforeEach(() => {
    page = new CustomersAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
