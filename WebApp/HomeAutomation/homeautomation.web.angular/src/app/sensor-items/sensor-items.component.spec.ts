import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorItemsComponent } from './sensor-items.component';

describe('SensorItemsComponent', () => {
  let component: SensorItemsComponent;
  let fixture: ComponentFixture<SensorItemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SensorItemsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SensorItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
