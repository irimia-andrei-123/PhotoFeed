import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LeaderboardsComponent } from './leaderboards/leaderboards.component';
import { HomepageComponent } from './homepage/homepage.component';
import { SearchpageComponent } from './searchpage/searchpage.component';
import { AuthGuardService } from './Services/AuthService/AuthGuard';
import { UploadComponent } from './upload/upload.component';
import { ImageComponent } from './image/image.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { UserFollowersComponent } from './user-followers/user-followers.component';
import { UserFollowingComponent } from './user-following/user-following.component';
import { UserPortfolioComponent } from './user-portfolio/user-portfolio.component';
import { UserSettingsComponent } from './user-settings/user-settings.component';
import { UserRatingComponent } from './user-rating/user-rating.component';
import { CompanyMembersComponent } from './company-members/company-members.component';
import { CompanyManageContestsComponent } from './company-manage-contests/company-manage-contests.component';
import { AdminMenuComponent } from './admin-menu/admin-menu.component';
import { AdminManageUsersComponent } from './admin-manage-users/admin-manage-users.component';
import { AdminManageCompaniesComponent } from './admin-manage-companies/admin-manage-companies.component';
import { AdminCreateContestComponent } from './admin-manage-create-contest/admin-manage-create-contest.component';
import { AdminManageContestsComponent } from './admin-manage-contests/admin-manage-contests.component';
import { CompanyContestComponent } from './company-contest/company-contest.component';
import { FeedbackCategoriesComponent } from './feedback-categories/feedback-categories.component';
import { FeedbackCategoryComponent } from './feedback-category/feedback-category.component';
import { UserFeedbackComponent } from './feedback-user/feedback-user.component';
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
import { AdminGuardService } from './Services/AuthService/AdminGuard';
import { CompanyInfoComponent } from './company-info/company-info.component';
import { ImageFeedbackComponent } from './image-feedback/image-feedback.component';

const routes: Routes = [
  {path: 'startpage', component: StartPageComponent},
  {path: 'login', component: StartPageLoginComponent},
  {path: 'register-user', component: StartPageRegisterUserComponent},
  {path: 'register-company', component: StartPageRegisterCompanyComponent},

  {path: 'homepage', canActivate: [AuthGuardService], component: HomepageComponent},

  {path: 'categories', canActivate: [AuthGuardService], component: CategoriesListComponent},
  {path: 'category/:id', canActivate: [AuthGuardService], component: CategoriesImagesComponent},

  {path: 'feedback', canActivate: [AuthGuardService], component: FeedbackCategoriesComponent},
  {path: 'feedback-category/:id', canActivate: [AuthGuardService], component: FeedbackCategoryComponent},
  {path: 'user-feedback', canActivate: [AuthGuardService], component: UserFeedbackComponent},

  {path: 'basic-contests-list', canActivate: [AuthGuardService], component: ContestBasicListComponent},
  {path: 'basic-contest/:id', canActivate: [AuthGuardService], component: ContestBasicInfoComponent},
  {path: 'basic-contest-submissions/:id', canActivate: [AuthGuardService], component: ContestBasicSubmissionsComponent},

  {path: 'pro-contests-list', canActivate: [AuthGuardService], component: ContestProListComponent},
  {path: 'pro-contest/:id', canActivate: [AuthGuardService], component: ContestProInfoComponent},
  {path: 'pro-contest-submissions/:id', canActivate: [AuthGuardService], component: ContestProSubmissionsComponent},

  {path: 'leaderboards', canActivate: [AuthGuardService], component: LeaderboardsComponent},

  {path: 'search', canActivate: [AuthGuardService], component: SearchpageComponent},

  {path: 'user/:id', canActivate: [AuthGuardService], component: UserInfoComponent},
  {path: 'user-followers/:id', canActivate: [AuthGuardService], component: UserFollowersComponent},
  {path: 'user-following/:id', canActivate: [AuthGuardService], component: UserFollowingComponent},
  {path: 'user-portfolio/:id', canActivate: [AuthGuardService], component: UserPortfolioComponent},
  {path: 'user-settings', canActivate: [AuthGuardService], component: UserSettingsComponent},
  {path: 'user-rating/:id', canActivate: [AuthGuardService], component: UserRatingComponent},

  {path: 'comapny/:id', canActivate: [AuthGuardService], component: CompanyInfoComponent},
  {path: 'comapny-portfolio/:id', canActivate: [AuthGuardService], component: UserPortfolioComponent},
  {path: 'comapny-settings', canActivate: [AuthGuardService], component: UserSettingsComponent},
  {path: 'comapny-rating/:id', canActivate: [AuthGuardService], component: UserRatingComponent},

  {path: 'company-members/:id', canActivate: [AuthGuardService], component: CompanyMembersComponent},
  {path: 'company-contests/:id', canActivate: [AuthGuardService], component: CompanyManageContestsComponent},
  {path: 'company-new-contest', canActivate: [AuthGuardService], component: CompanyContestComponent},

  {path: 'admin-manage', canActivate: [AdminGuardService], component: AdminMenuComponent},
  {path: 'admin-manage-users', canActivate: [AdminGuardService], component: AdminManageUsersComponent},
  {path: 'admin-manage-companies', canActivate: [AdminGuardService], component: AdminManageCompaniesComponent},
  {path: 'admin-create-contest', canActivate: [AdminGuardService], component: AdminCreateContestComponent},
  {path: 'admin-manage-contests', canActivate: [AdminGuardService], component: AdminManageContestsComponent},

  {path: 'upload', canActivate: [AuthGuardService], component: UploadComponent},

  {path: 'image/:id', canActivate: [AuthGuardService], component: ImageComponent},
  {path: 'image-feedback/:id', canActivate: [AuthGuardService], component: ImageFeedbackComponent},

  {path: '**', redirectTo: 'startpage', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
