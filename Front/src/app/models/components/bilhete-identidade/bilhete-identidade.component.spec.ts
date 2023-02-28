import {ComponentFixture, TestBed} from '@angular/core/testing';

import {BilheteIdentidadeComponent} from './bilhete-identidade.component';

describe('BilheteIdentidadeComponent', () => {
  let component: BilheteIdentidadeComponent;
  let fixture: ComponentFixture<BilheteIdentidadeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BilheteIdentidadeComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(BilheteIdentidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
