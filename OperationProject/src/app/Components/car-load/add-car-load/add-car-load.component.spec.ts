import {ComponentFixture, TestBed} from '@angular/core/testing';

import {AddCarLoadComponent} from './add-car-load.component';

describe('AddCarLoadComponent', () => {
  let component: AddCarLoadComponent;
  let fixture: ComponentFixture<AddCarLoadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddCarLoadComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(AddCarLoadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
