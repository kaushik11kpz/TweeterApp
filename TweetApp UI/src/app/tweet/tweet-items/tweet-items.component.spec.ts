import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TweetItemsComponent } from './tweet-items.component';

describe('TweetItemsComponent', () => {
  let component: TweetItemsComponent;
  let fixture: ComponentFixture<TweetItemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TweetItemsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TweetItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
