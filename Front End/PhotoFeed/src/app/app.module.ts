import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatMenuModule } from '@angular/material/menu';
import { MatCardModule, MatDialogModule, MatButtonModule, MatTableModule, MatFormFieldModule,
  MatSelectModule, MatInputModule, MatChipsModule, MatIconModule, MatAutocompleteModule, MatSliderModule } from '@angular/material';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomepageComponent } from './homepage/homepage.component';
import { LeaderboardsComponent } from './leaderboards/leaderboards.component';
import { SearchpageComponent } from './searchpage/searchpage.component';
import { NguiInViewComponent } from './Helpers/ngui-in-view.component';
import { UploadComponent } from './upload/upload.component';
import { ImageComponent } from './image/image.component';
import { UserFeedbackComponent } from './feedback-user/feedback-user.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { UserFollowersComponent } from './user-followers/user-followers.component';
import { UserFollowingComponent } from './user-following/user-following.component';
import { UserPortfolioComponent } from './user-portfolio/user-portfolio.component';
import { CompanyMembersComponent } from './company-members/company-members.component';
import { CompanyManageContestsComponent } from './company-manage-contests/company-manage-contests.component';
import { UserSettingsComponent } from './user-settings/user-settings.component';
import { UserRatingComponent } from './user-rating/user-rating.component';
import { AdminMenuComponent } from './admin-menu/admin-menu.component';
import { AdminManageUsersComponent } from './admin-manage-users/admin-manage-users.component';
import { AdminManageCompaniesComponent } from './admin-manage-companies/admin-manage-companies.component';
import { AdminCreateContestComponent } from './admin-manage-create-contest/admin-manage-create-contest.component';
import { AdminManageContestsComponent } from './admin-manage-contests/admin-manage-contests.component';
import { CompanyContestComponent } from './company-contest/company-contest.component';
import { FeedbackCategoriesComponent } from './feedback-categories/feedback-categories.component';
import { FeedbackCategoryComponent } from './feedback-category/feedback-category.component';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { CategoriesImagesComponent } from './categories-images/categories-images.component';
import { ContestBasicListComponent } from './contest-basic-list/contest-basic-list.component';
import { ContestBasicInfoComponent } from './contest-basic-info/contest-basic-info.component';
import { ContestBasicSubmissionsComponent } from './contest-basic-submissions/contest-basic-submissions.component';
import { ContestProListComponent } from './contest-pro-list/contest-pro-list.component';
import { ContestProInfoComponent } from './contest-pro-info/contest-pro-info.component';
import { ContestProSubmissionsComponent } from './contest-pro-submissions/contest-pro-submissions.component';
import { StartPageComponent } from './start-page/start-page.component';
import { StartPageLoginComponent } from './start-page-login/start-page-login.component';
import { StartPageRegisterUserComponent } from './start-page-register-user/start-page-register-user.component';
import { StartPageRegisterCompanyComponent } from './start-page-register-company/start-page-register-company.component';
import { CompanyInfoComponent } from './company-info/company-info.component';
import { ImageFeedbackComponent } from './image-feedback/image-feedback.component';

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    LeaderboardsComponent,
    SearchpageComponent,
    NguiInViewComponent,
    UploadComponent,
    ImageComponent,
    UserFeedbackComponent,
    UserInfoComponent,
    UserFollowersComponent,
    UserFollowingComponent,
    UserPortfolioComponent,
    CompanyMembersComponent,
    CompanyManageContestsComponent,
    UserSettingsComponent,
    UserRatingComponent,
    AdminMenuComponent,
    AdminManageUsersComponent,
    AdminManageCompaniesComponent,
    AdminManageContestsComponent,
    AdminCreateContestComponent,
    CompanyContestComponent,
    FeedbackCategoriesComponent,
    FeedbackCategoryComponent,
    CategoriesListComponent,
    CategoriesImagesComponent,
    ContestBasicListComponent,
    ContestBasicInfoComponent,
    ContestBasicSubmissionsComponent,
    ContestProListComponent,
    ContestProInfoComponent,
    ContestProSubmissionsComponent,
    StartPageComponent,
    StartPageLoginComponent,
    StartPageRegisterUserComponent,
    StartPageRegisterCompanyComponent,
    CompanyInfoComponent,
    ImageFeedbackComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    FlexLayoutModule,
    MatMenuModule,
    MatCardModule,
    MatDialogModule,
    MatButtonModule,
    MatTableModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatChipsModule,
    MatIconModule,
    MatAutocompleteModule,
    MatSliderModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
