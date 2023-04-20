import {ComponentFixture, TestBed} from '@angular/core/testing';

import {SidenavAutosizeExample} from './sidenav-autosize-example.component';

describe('SidenavComponent', () => {
  let component: SidenavAutosizeExample;
  let fixture: ComponentFixture<SidenavAutosizeExample>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SidenavAutosizeExample]
    })
      .compileComponents();

    fixture = TestBed.createComponent(SidenavAutosizeExample);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
