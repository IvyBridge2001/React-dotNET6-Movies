//d is for Type Definition file

export interface movieDTO{
    id: number;
    title: string;
    poster: string;
}

export interface landingPageDTO {
    inTheaters?: movieDTO[];
    upcomingReleases?: movieDTO[];
}